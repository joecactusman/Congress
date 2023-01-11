const uri = 'api/members';
let todos = [];

function getItems() {
    fetch(uri + '/MemberData')
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
    let searchField = document.createElement('input');
    searchField.setAttribute('type', 'text');
    const pBody = document.getElementById('searchHere');
    pBody.innerHTML = '';
    pBody.appendChild(searchField);
}

function _displayItems(data) {
    const tBody = document.getElementById('counter');
    tBody.innerHTML = '';
    let table = document.createElement('table');
    table.type = 'table';
    table.disabled = true;
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