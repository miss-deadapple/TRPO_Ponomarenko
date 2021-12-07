using System.Collections.Generic;
using System.Windows.Input;
using CreateAuthorize.Model;
using CreateAuthorize.View.ViewModel;

namespace CreateAuthorize.ViewModel
{
    public class SignUpViewModel: ViewModelBase
    {
        private UserRepository _repository = new UserRepository();
        private const string DEFAULT_VALUE_LOGIN = "Логин";
        private const string DEFAULT_VALUE_PASSWORD = "Пароль";
        private const string DEFAULT_VALUE_FIRST_NAME = "Имя";
        private const string DEFAULT_VALUE_LAST_NAME = "Фамилия";
        private const string DEFAULT_VALUE_MIDDLE_NAME = "Отчество";
        private string _firstNameValue = DEFAULT_VALUE_FIRST_NAME;
        public string firstNameValue
        {
            get => _firstNameValue;
            set
            {
                _firstNameValue = value;
                OnPropertyChanged(nameof(firstNameValue));
            }
        }
        private string _lastNameValue = DEFAULT_VALUE_LAST_NAME;

        public string lastNameValue
        {
            get => _lastNameValue;
            set
            {
                _lastNameValue = value;
                OnPropertyChanged(nameof(lastNameValue));
            }
        }

        private string _middleNameValue = DEFAULT_VALUE_MIDDLE_NAME;

        public string middleNameValue
        {
            get => _middleNameValue;
            set
            {
                _middleNameValue = value;
                OnPropertyChanged(nameof(middleNameValue));
            }
        }

        private string _loginValue = DEFAULT_VALUE_LOGIN;

        public string loginValue
        {
            get => _loginValue;
            set
            {
                _loginValue = value;
                OnPropertyChanged(nameof(loginValue));
            }
        }

        private string _passwordValue = DEFAULT_VALUE_PASSWORD;

        public string passwordValue
        {
            get => _passwordValue;
            set
            {
                _passwordValue = value;
                OnPropertyChanged(nameof(passwordValue));
            }
        }

        private string _signUpStatusValue = "Статус регистрации";

        public string signUpStatusValue
        {
            get => _signUpStatusValue;
            set
            {
                _signUpStatusValue = value;
                OnPropertyChanged(nameof(signUpStatusValue));
            }
        }

        public ICommand SignUpButton
        {
            get => new DelegateCommand(
                async o =>
                {
                    if (isValidCredentials()) changeSignUpStatus(await _repository.SignUpTask(_credentials));
                    else signUpStatusValue = "Введите данные";
                },
                o =>
                {
                    return isValidCredentials();
                }
                );
        }

        private bool isValidCredentials()
        {
            int isValidCount = 0;
            foreach (var credential in _credentials.Values)
            {
                if (credential != DEFAULT_VALUE_LOGIN &&
                    credential != DEFAULT_VALUE_LAST_NAME &&
                    credential != DEFAULT_VALUE_PASSWORD &&
                    credential != DEFAULT_VALUE_FIRST_NAME &&
                    credential != DEFAULT_VALUE_MIDDLE_NAME &&
                    credential != ""
                ) isValidCount += 1;
            }
            if (isValidCount > _credentials.Values.Count - 1) return true;
            else return false;
        }

        private Dictionary<UserModel, string> _credentials
        {
            get
            {
                Dictionary<UserModel, string> credentials = new Dictionary<UserModel, string>();
                credentials[UserModel.LOGIN] = loginValue;
                credentials[UserModel.PASSWORD] = passwordValue;
                credentials[UserModel.FIRST_NAME] = firstNameValue;
                credentials[UserModel.LAST_NAME] = lastNameValue;
                credentials[UserModel.MIDDLE_NAME] = middleNameValue;
                return credentials;
            }
        }

        private void changeSignUpStatus(bool status)
        {
            if (status) signUpStatusValue = "Регистрация успешна";
            else signUpStatusValue = "Ошибка регистрации";
        }
        
        
    }
}