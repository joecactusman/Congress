const uri = 'api/members';
let todos = [];

function getItems() {
    fetch(uri + '/MemberData')
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
    let searchField = document.createElement('input');
    searchField.setAttribute('type', 'text');
    searchField.id = 'searchField';
    let searchButton = document.createElement('button');
    searchButton.innerText = 'Search';
    searchButton.setAttribute('onclick', 'searchMembers()');
    const pBody = document.getElementById('searchHere');
    const button = document.createElement('button');
    button.innerText = 'Search';
    var searchTerm = searchField.value;
    button.setAttribute('onclick', `searchMembers(document.getElementById('input').value)`);
    pBody.innerHTML = '';
    pBody.appendChild(searchField);
    pBody.appendChild(button);
}

function getSenateItems() {
    fetch(uri + '/SenateMemberData')
        .then(response => response.json())
        .then(data => _displaySenateItems(data))
        .catch(error => console.error('Unable to get items.', error));
    let searchFieldSenate = document.createElement('input');
    searchFieldSenate.setAttribute('type', 'text');
    searchFieldSenate.id = 'searchFieldSenate';
    let searchButtonSenate = document.createElement('button');
    searchButtonSenate.innerText = 'Search';
    searchButtonSenate.setAttribute('onclick', 'searchMembers()');
    const pBody = document.getElementById('searchHereSenate');
    const buttonSenate = document.createElement('button');
    buttonSenate.innerText = 'Search';
    var searchTerm = searchFieldSenate.value;
    buttonSenate.setAttribute('onclick', `searchMembers(document.getElementById('inputSenate').value)`);
    pBody.innerHTML = '';
    pBody.appendChild(searchFieldSenate);
    pBody.appendChild(buttonSenate);
}

function searchMembers() {
    let searchTerm = document.getElementById('searchField').value;
    fetch(`${uri}/Search/${searchTerm}`)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('counter');
    tBody.innerHTML = '';
    let table = document.createElement('table');
    let tableSenate = document.createElement('tableSenate');
    tableSenate.type = 'table';
    tableSenate.disabled = true;
    //let searchButton = document.createElement('button');
    //searchButton.setAttribute('type', 'submit');
    table.type = 'table';
    table.disabled = true;
    let searchField = document.createElement('input');
    searchField.setAttribute('type', 'text');
    searchField.id = 'searchField';
    const pBody = document.getElementById('searchHere');
    const button = document.createElement('button');
    button.innerText = 'Search';
    button.setAttribute('onclick', `searchMembers(document.getElementById('input.innerhtml'))`);
    pBody.innerHTML = '';
    pBody.appendChild(searchField);
    pBody.appendChild(button);
    let searchFieldSenate = document.createElement('inputSenate');
    searchFieldSenate.setAttribute('type', 'text');
    searchFieldSenate.id = 'searchField';
    const pBodySenate = document.getElementById('searchHereSenate');
    const buttonSenate = document.createElement('buttonSenate');
    buttonSenate.innerText = 'Search';
    buttonSenate.setAttribute('onclick', `searchMembers(document.getElementById('inputSenate.innerhtml'))`);
    //pBodySenate.innerHTML = '';
    //pBodySenate.appendChild(searchFieldSenate);
    //pBodySenate.appendChild(buttonSenate);
    let hr = table.insertRow();
    hr.insertCell(0).innerHTML = 'Name';
    hr.insertCell(1).innerHTML = 'Affiliation';

    data.forEach(item => {
        if (item != null && item.district == null) {
            item.district = '';
        }
        let tr = table.insertRow();
        tr.insertCell(0).innerHTML = item.last_name + ', ' + item.first_name;
        tr.insertCell(1).innerHTML = item.party + ' - ' + item.state + ' ' + item.district;
    });
    tBody.appendChild(table);
    todos = data;
}

function _displaySenateItems(data) {
    const tBody = document.getElementById('counterSenate');
    tBody.innerHTML = '';
    let table = document.createElement('table');
    let tableSenate = document.createElement('table');
    tableSenate.type = 'table';
    tableSenate.disabled = true;
    //let searchButton = document.createElement('button');
    //searchButton.setAttribute('type', 'submit');
    table.type = 'table';
    table.disabled = true;
    let searchField = document.createElement('input');
    searchField.setAttribute('type', 'text');
    searchField.id = 'searchFieldSenate';
    const pBody = document.getElementById('searchHere');
    const button = document.createElement('button');
    button.innerText = 'Search';
    button.setAttribute('onclick', `searchMembers(document.getElementById('input.innerhtml'))`);
    pBody.innerHTML = '';
    pBody.appendChild(searchField);
    pBody.appendChild(button);
    let searchFieldSenate = document.createElement('input');
    searchFieldSenate.setAttribute('type', 'text');
    searchFieldSenate.id = 'searchFieldSenate';
    const pBodySenate = document.getElementById('searchHereSenate');
    const buttonSenate = document.createElement('button');
    buttonSenate.innerText = 'Search';
    buttonSenate.setAttribute('onclick', `searchMembers(document.getElementById('searchFieldSenate.innerhtml'))`);
    pBodySenate.innerHTML = '';
    pBodySenate.appendChild(searchFieldSenate);
    pBodySenate.appendChild(buttonSenate);
    let hr = tableSenate.insertRow();
    hr.insertCell(0).innerHTML = 'Name';
    hr.insertCell(1).innerHTML = 'Affiliation';

    data.forEach(item => {
        if (item != null && item.district == null) {
            item.district = '';
        }
        let tr = tableSenate.insertRow();
        tr.insertCell(0).innerHTML = item.last_name + ', ' + item.first_name;
        tr.insertCell(1).innerHTML = item.party + ' - ' + item.state + ' ' + item.district;
    });
    tBody.appendChild(tableSenate);
    todos = data;
}