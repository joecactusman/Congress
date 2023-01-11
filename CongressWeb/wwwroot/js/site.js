const uri = 'api/members';
let todos = [];

function getItems() {
    fetch(uri + '/MemberData')
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
    let searchField = document.createElement('input');
    searchField.setAttribute('type', 'text');
    let searchButton = document.createElement('button');
    searchButton.innerText = 'Search';
    searchButton.setAttribute('onclick', 'searchMembers()');
    const pBody = document.getElementById('searchHere');
    const button = document.createElement('button');
    button.innerText = 'Search';
    button.setAttribute('onclick', `searchMembers()`);
    pBody.innerHTML = '';
    pBody.appendChild(searchField);
    pBody.appendChild(button);
}

function searchMembers() {
    fetch(uri + '/Search')
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('counter');
    tBody.innerHTML = '';
    let table = document.createElement('table');
    //let searchButton = document.createElement('button');
    //searchButton.setAttribute('type', 'submit');
    table.type = 'table';
    table.disabled = true;
    let searchField = document.createElement('input');
    searchField.setAttribute('type', 'text');
    const pBody = document.getElementById('searchHere');
    const button = document.createElement('button');
    button.innerText = 'Search';
    button.setAttribute('onclick', `searchMembers()`);
    pBody.innerHTML = '';
    pBody.appendChild(searchField);
    pBody.appendChild(button);
    //searchButton.innerText = 'Search';
    //searchButton.setAttribute('action', 'javascript:void(0)')
    //searchButton.setAttribute('method', 'Get')
    //searchButton.setAttribute('onsubmit', 'searchMembers()');
    //pBody.appendChild(searchButton);
    let hr = table.insertRow();
    hr.insertCell(0).innerHTML = 'Name';
    hr.insertCell(1).innerHTML = 'Affiliation';
    data.forEach(item => {
        let tr = table.insertRow();
        tr.insertCell(0).innerHTML = item.last_name + ', ' + item.first_name;
        tr.insertCell(1).innerHTML = item.party + ' - ' + item.state + ' ' + item.district;
    });
    tBody.appendChild(table);
    todos = data;
}