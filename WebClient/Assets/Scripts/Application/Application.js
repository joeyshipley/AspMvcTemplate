var Application;
(function (Application) {
    (function (Account) {
        var LoginComponent = (function () {
            function LoginComponent(data) {
                if (typeof data === "undefined") { data = null; }
                if (!data)
                    return;

                var mapping = {};
                ko.mapping.fromJS(data, mapping, this);
            }
            return LoginComponent;
        })();
        Account.LoginComponent = LoginComponent;
    })(Application.Account || (Application.Account = {}));
    var Account = Application.Account;
})(Application || (Application = {}));
/// <reference path="LoginComponent.ts" />
/// <reference path="Account/_namespace.ts" />
