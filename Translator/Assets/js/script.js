function userInputTimer(txtInput) {
    var typingTimer;
    //var stopTypingInterval = 3000;  //3 seconds
    var typingResult = txtInput;
    //var myInput = document.getElementById('myInput');

    //on keyup, start the countdown
    typingResult.addEventListener('keyup', () => {
        clearTimeout(typingTimer);
        if (typingResult.value) {
            typingTimer = setTimeout(doneTyping, 3000); //3 sec
        }
    });

    //user is "finished typing," do something
    function doneTyping() {
        console.log('Finished!');
        //<%#Translator.Translator.TranslateInput() %>
        $("#btnOk").click();
    }
}