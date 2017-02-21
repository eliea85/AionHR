function CheckSession() {
    var id = App.direct.CheckSession({
        success: function (result) {

            if (result == "0") {

                window.open('../ARLogin.aspx?timeout=yes', '_parent');
                return false;
            }

        }
    })
}