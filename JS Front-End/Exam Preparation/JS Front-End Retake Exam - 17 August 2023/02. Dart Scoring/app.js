window.addEventListener("load", solve);

function solve() {
    let nameElm = document.getElementById("player");
    let scoreElm = document.getElementById("score");
    let roundElm = document.getElementById("round");

    let addBtn = document.getElementById("add-btn");
    let clearBtn = document.querySelector(".btn.clear");

    let reviewUl = document.getElementById("sure-list");
    let scoreboardUl = document.getElementById("scoreboard-list")

    let players = [];

    addBtn.addEventListener('click', () => addPlayer(nameElm, scoreElm, roundElm));
    clearBtn.addEventListener('click', () => {
        location.reload();
    });

    function addPlayer(nameInput, scoreInput, roundInput) {
        let li = document.createElement('li');

        let article = document.createElement('article');

        let player = getInfo(nameElm, scoreElm, roundElm);

        let pName = document.createElement('p');
        pName.textContent = `${player.name}`;
        let pScore = document.createElement('p');
        pScore.textContent = `Score: ${player.score}`;
        let pRound = document.createElement('p');
        pRound.textContent = `Round: ${player.round}`;

        article.appendChild(pName);
        article.appendChild(pScore);
        article.appendChild(pRound);

        let editBtn = document.createElement('button');
        editBtn.classList.add("btn");
        editBtn.classList.add("edit");
        editBtn.textContent = 'edit';

        editBtn.addEventListener('click', () => editPlayer(player.name, player.score, player.round));

        let okBtn = document.createElement('button');
        okBtn.classList.add("btn");
        okBtn.classList.add("ok");
        okBtn.textContent = 'ok';


        li.classList.add("dart-item");
        li.appendChild(article);
        li.appendChild(editBtn);
        li.appendChild(okBtn);

        reviewUl.appendChild(li);

        addBtn.disabled = true;
        nameElm.value = '';
        scoreElm.value = '';
        roundElm.value = '';

        okBtn.addEventListener('click', () => addScoreboard(li))

        function getInfo(nameInput, scoreInput, roundInput) {
            return {
                name: nameInput.value,
                score: Number(scoreInput.value),
                round: Number(roundInput.value)
            }
        }
    }

    function editPlayer(name, score, round) {
        reviewUl.innerHTML = '';

        nameElm.value = name;
        scoreElm.value = score;
        roundElm.value = round;

        addBtn.disabled = false;
    }

    function addScoreboard(li) {
        reviewUl.innerHTML = '';

        li.removeChild(li.lastChild);
        li.removeChild(li.lastChild);

        scoreboardUl.appendChild(li);

        addBtn.disabled = false;
    }
}
  