var Application;
(function (Application) {
    (function (Account) {
        var LoginModel = (function () {
            function LoginModel(data) {
                if (typeof data === "undefined") { data = null; }
                if (!data)
                    return;

                var mapping = {};
                ko.mapping.fromJS(data, mapping, this);
            }
            return LoginModel;
        })();
        Account.LoginModel = LoginModel;
    })(Application.Account || (Application.Account = {}));
    var Account = Application.Account;
})(Application || (Application = {}));
//# sourceMappingURL=LoginModel.js.map
