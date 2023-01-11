const uri = 'api/members/fuckoff';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('counter');
    tBody.innerHTML = '';
    let table = document.createElement('table');
    table.type = 'table';
    table.disabled = true;
    let hr = table.insertRow();
    hr.insertCell(0).innerHTML = 'Name';
    hr.insertCell(1).innerHTML = 'State';
    hr.insertCell(2).innerHTML = 'District';
    data.forEach(item => {
        let tr = table.insertRow();
        tr.insertCell(0).innerHTML = item.Name;
        tr.insertCell(1).innerHTML = item.State;
        tr.insertCell(2).innerHTML = item.District;
    });
    tBody.appendChild(table);
    todos = data;
}