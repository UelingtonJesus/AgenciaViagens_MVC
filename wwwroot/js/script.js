
function criaTag(tag){
    return document.createElement(tag);
}

let tabela = document.getElementById('table');

let thead = criaTag("thead");
let tbody = criaTag("tbody");
let tfoot = criaTag("tfoot");

let destinos = ["Cidade", "País"];
let linhaHead = criaTag("tr");

let linhastabela = [
    ["Ilhas Maldivas", "Maldivas" ],
    ["Paris", "França" ],
    ["Caribe", "República Dominicana" ],
    ["Angra dos Reis", "Brasil" ],
    ["Santiago", "Chile" ],
    ["Flórida", "Estados Unidos" ],
    ["Fortaleza", "Brasil" ],
    ["Genebra", "Suiça" ],
    ["Recife", "Brasil" ],
    ["Salvador", "Brasil" ],
    ["São Paulo", "Brasil" ],
    ["Roma", "Itália" ],
    ["Barcelona", "Espanha" ],
    ["Madrid", "Espanha" ],
    ["Lisboa", "Portugal" ],
    ["Jerusalém", "Israel"]
    
]

function criaColuna(tag, text){
    tag = criaTag(tag);
    tag.textContent = text;
    return tag;
}

for(let i = 0; i < destinos.length; i++){
    let th = criaColuna("th", destinos[i]);
    
    linhaHead.appendChild(th);
}

thead.appendChild(linhaHead);



for(let i = 0, linhaBody = ""; i < linhastabela.length; i++){
    linhaBody = criaTag("tr");
    linhaBody.appendChild(criaColuna("td", (i+1)));
    if(i % 2 != 0){
        linhaBody.setAttribute("class", "tr.listrada");
    }
    for(let j = 0, col = ""; j < linhastabela[i].length; j++){
        col = criaColuna("td", linhastabela[i][j]);
        linhaBody.appendChild(col);
    }
    tbody.appendChild(linhaBody);
}


tabela.appendChild(thead);
tabela.appendChild(tbody);
tabela.appendChild(tfoot);
