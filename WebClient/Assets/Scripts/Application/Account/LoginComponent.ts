module Application.Account
{
    declare var ko;

    export class LoginComponent
    {
        constructor(data: any = null)
        {
            if (!data)
                return;

            var mapping = {};
            ko.mapping.fromJS(data, mapping, this);
        }
    }
}