using System.Windows.Input;
using CreateAuthorize.Model;
using CreateAuthorize.View.ViewModel;

namespace CreateAuthorize.ViewModel
{
    public class AuthorizationViewModel: ViewModelBase
    {
        private UserRepository _repository = new UserRepository();
        private string _loginValue = "Логин";
        public string loginValue
        {
            get => _loginValue;
            set
            {
                _loginValue = value;
                OnPropertyChanged(nameof(loginValue));
            }
        }
        
        private string _passwordValue = "Пароль";
        public string passwordValue
        {
            get => _passwordValue;
            set
            {
                _passwordValue = value;
                OnPropertyChanged(nameof(passwordValue));
            }
        }

        private string _signInStatusValue = "Статус авторизации";
        public string signInStatusValue
        {
            get => _signInStatusValue;
            set
            {
                _signInStatusValue = value;
                OnPropertyChanged(nameof(signInStatusValue));
            }
        }

        public ICommand SignInButton
        {
            get => new DelegateCommand(async o =>
                {
                    if (isValidCredentials())
                        changeSignInStatus(await _repository.SignInTask(loginValue, passwordValue));
                    else signInStatusValue = "Введите данные";
                },
                    o =>
                    {
                        return isValidCredentials();
                    }
                );
        }

        private bool isValidCredentials()
        {
            if (
                loginValue != "Логин" && 
                passwordValue != "Пароль" && 
                loginValue != "" && 
                passwordValue != ""
                ) return true;
            else return false;
        }
        
        private void changeSignInStatus(bool status)
        {
            if (status) signInStatusValue = "Авторизация успешна";
            else signInStatusValue = "Ошибка авторизации";
        }
    }
}