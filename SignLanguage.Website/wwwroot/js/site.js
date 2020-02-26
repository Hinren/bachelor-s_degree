$("button").click(function () {
    var getIdNumber = this.id;
    var createViewRowIdToToogle = ".views-row-" + getIdNumber;
    $(createViewRowIdToToogle).slideToggle("fast");
});

var points = 0;
function selectButton(content) {

    var className = content.classList;
    var getValue = content.innerHTML;
    var allButton = content.parentElement;
    for (var i = 0; i < allButton.children.length; i++) {
        if (allButton.children[i].innerText !== getValue) {
            var actualClassName = allButton.children[i].classList;
            if (actualClassName.contains('selected')) {
                actualClassName.remove('selected');
                if (actualClassName.contains('correct')) {
                    points -= 1;
                }
            }
        }
    }
    if (className.contains('selected')) {
        className.remove('selected');
        if (className.contains('correct')) {
            points -= 1;
        }

    }
    else {
        if (className.contains('correct')) {
            points += 1;
        }
        className.add('selected');
    }
}

var answersBtns = document.querySelectorAll('.answer');

var checkPointsBtn = document.querySelector('.check-points');

var pointsContainer = document.querySelector('.points');

var pointsSpan = document.querySelector('.points span');

var showAnswersBtn = document.querySelector('.show-answers');

function showPoints() {
    pointsSpan.innerHTML = points;
    pointsContainer.classList.add('show');
}

function showAnswers() {
    for (var i = 0; i < answersBtns.length; i++) {
        answersBtns[i].classList.remove('selected');
        if (answersBtns[i].classList.contains('correct')) {
            answersBtns[i].classList.add('show-correct');
        }
    }
}

checkPointsBtn.addEventListener('click', showPoints);

showAnswersBtn.addEventListener('click', showAnswers);

$(".btn").click(function () {
    var className = $(this).attr('class');
    var getAllClass = className.split(' ');
    var getIdCLass = getAllClass[getAllClass.length - 1];
    var getUrlToModal = $('.data-' + getIdCLass).attr('src');
    var findYoutube = getUrlToModal.split('.');
    if (findYoutube !== undefined) {
        if (findYoutube[1] === "youtube") {
            $(".my_video").attr("src", getUrlToModal).height("496").width("702");
            $(".my_image").height("0").width("0");
        }
        else {
            $(".my_image").attr("src", getUrlToModal).height("496").width("702");
            $(".my_video").height("0").width("0");
        }
    }

});

document.getElementById("save-value-to-send-points").addEventListener("click", function () {
    document.getElementById("send-points").value = points;
}, false);