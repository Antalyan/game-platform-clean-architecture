import { URL } from 'https://jslib.k6.io/url/1.0.0/index.js';
import http from "k6/http";
import { check } from 'k6';

const username = 'adam@ananas';
const password = 'AdamAnanas1!';

const urlBase = 'https://localhost:5001/api/'
const headers = {
    'Accept': '*/*',
    'Content-Type': 'application/json',
    'Host': 'localhost:5001',
    'Origin': 'https://localhost:5001',
};

function auth() {
    const url = urlBase + 'Users/login';
    const data = {
        "email": username,
        "password": password,
    };

    let response = http.post(url, JSON.stringify(data), {headers: headers});

    check(response, {
        'Authentication: status is 200': (r) => r.status === 200,
    });
    
    let parsedBody = JSON.parse(response.body);
    const accessToken = parsedBody.accessToken;
    headers['Authorization'] = `Bearer ${accessToken}`
}

function testGame01RuleCreation() {
    // Create rules
    const urlCommand = urlBase + 'Rules';
    const data = {
        "players": 4,
        "winningCondition": "EmptyHand",
        "gameType": "MauMau",
        "cardsDrawnPerTurn": 2,
        "cardsDrawnInitially": 4,
        "cardsPlayedPerTurn": 1,
        "cardsHandLimit": 10
    };
    let commandResponse = http.post(urlCommand, JSON.stringify(data), {headers: headers});
    check(commandResponse, {
        'Test 01 rule creation status is 200': (r) => r.status === 200,
    });
    
    // Get rules
    const urlQuery = new URL(urlBase + 'Rules');
    urlQuery.searchParams.append('RulesId', commandResponse.json());
    let queryResponse = http.get(urlQuery.toString(), {headers: headers});
    check(queryResponse, {
        'Test 01 query rule status is 200': (r) => r.status === 200,
        'Test 01 is correct body': (r) =>
            Object.keys(data).every(key => data.key === r.json().key)
    });
}

function testGame02DeckCreationAndCardAssignment() {
    // Create deck
    let urlCommand = urlBase + 'GameDeck/create';
    const deckData = {
        "name": "Amazing Deck",
        "gameType": "MauMau"
    };
    let commandResponse = http.post(urlCommand, JSON.stringify(deckData), {headers: headers});
    check(commandResponse, {
        'Test 02 deck creation status is 200': (r) => r.status === 200,
    });
    const insertedDeckId = commandResponse.json();

    // Assign card to deck four times
    let iterations = 4
    urlCommand = urlBase + 'GameDeck/addCard';
    const cardData = {
        "deckId": insertedDeckId,
        "cardId": 1 // Creating cards is not a part of this test
    };
    for (let i = 0; i < iterations; i++) {
        commandResponse = http.post(urlCommand, JSON.stringify(cardData), {headers: headers});
        check(commandResponse, {
            'Test 02 card insertion status is 204': (r) => r.status === 204,
        });
    }

    const urlQuery = new URL(urlBase + 'GameDeck');
    urlQuery.searchParams.append('GameDeckId', insertedDeckId);
    let queryResponse = http.get(urlQuery.toString(), {headers: headers});
    check(queryResponse, {
        'Test 02 query status is 200': (r) => r.status === 200,
        'Test 02 is correct body': (r) =>
            r.json().name === deckData.name && r.json().cardList[0].quantity === iterations
    });
}

// Uses preseeded data
function testGame03GameCreationAndDeletion() {
    // Create game
    let urlCommand = urlBase + 'Game/submit';
    const gameData = {
        "name": "string" + Date.now(), // New name is required every time because of uniqueness requirement
        "deckId": 3,
        "rulesId": 2,
        "visibility": "Public",
    };

    // Unsuccessfully create game where deck and rules game types do not match
    let commandResponse = http.post(urlCommand, JSON.stringify(gameData), {headers: headers});
    check(commandResponse, {
        'Test 03 not matching creation is error': (r) => r.status > 400,
    });

    // Create game where deck and rules game types do match
    gameData.rulesId = 1;
    commandResponse = http.post(urlCommand, JSON.stringify(gameData), {headers: headers});
    check(commandResponse, {
        'Test 03 game creation status is 200': (r) => r.status === 200,
    });
    const insertedGameId = commandResponse.json();

    // Delete created game
    urlCommand = urlBase + `Game/${insertedGameId}`;
    commandResponse = http.del(urlCommand, null, {headers: headers});
    console.log(commandResponse)
    check(commandResponse, {
        'Test 03 game deletion status is 204': (r) => r.status === 204,
    });

    // Unsuccessfully attempt to delete same game again
    commandResponse = http.del(urlCommand, null, {headers: headers});
    check(commandResponse, {
        'Test 03 repeated deletion is error': (r) => r.status > 400,
    });
}

export default function runTests() {
    auth();
    testGame01RuleCreation()
    testGame02DeckCreationAndCardAssignment()
    testGame03GameCreationAndDeletion()
}



