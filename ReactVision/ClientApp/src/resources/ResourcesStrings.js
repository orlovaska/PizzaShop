import LocalizedStrings from "react-localization";

// Инициализация:
const strings = new LocalizedStrings({
  ru: {
    app: {
      buttons: {
        your: "Тоже моя кнопка",
        my: "Моя кнопка",
      },
    },
    loginForm: {
      login: "Вход",
      password: "Пароль",
      email: "Email",
      enterYourEmail: "Введите свой email",
      enterYourPassword: "Введите свой пароль",
      signIn: "Войти",
      noAccount: "Ещё нет аккаунта?",
      signUp: "Зарегистрироваться",
      error: {
        emailEmptyError: "Email не может быть пустым",
        emailWrongFormatError: "Email не соответсвует формату",
          passwordEmptyError: "Пароль не может быть пустым",
          wrongLoginOrPassword: "Неверный логин или пароль"
      },
    },
    signupForm: {
      registration: "Регистрация",
      password: "Пароль",
      confirmPassword: "Повторите пароль",
      enterYourFullname: "Введите имя и фамилию",
      enterYourPhone: "Введите номер телефона",
      enterYourEmail: "Введите email",
      enterYourPassword: "Введите пароль",
      signUp: "Зарегистрироваться",
      haveAccount: "Уже есть аккаунт?",
      signIn: "Войти",
      error: {
        emailEmptyError: "Email не может быть пустым",
        emailWrongFormatError: "Email не соответсвует формату",
        passwordEmptyError: "Пароль не может быть пустым",
        fullNameEmptyError: "Полное имя не может быть пустым",
        fullNameWrongFormatError: "Полное имя не соответсвует формату",
        phoneEmptyError: "Номер телефона не может быть пустым",
        phoneWrongFormatError: "Номер телефона не соответсвует формату",
      },
    },
  },
});

export default strings;
