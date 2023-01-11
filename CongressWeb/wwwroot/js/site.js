const uri = 'api/members/fuckoff';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';
    let table = document.createElement('table');
    table.type = 'table';
    table.disabled = true;

    data.forEach(item => {
        let tr = table.insertRow();

        tr.insertCell(0).innerHTML = item.Name;
        tr.insertCell(0).innerHTML = item.Name;
        tr.insertCell(0).innerHTML = item.Name;
    });
    tBody.appendChild(table);
    todos = data;
}