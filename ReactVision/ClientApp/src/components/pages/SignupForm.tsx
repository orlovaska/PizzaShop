import React, { useEffect, useState } from "react";
import strings from "../../resources/ResourcesStrings";
import "./Login/LoginForm.css";
import { emailIsUnique, addCustomer } from "../../services/dataService.ts";
import { useUserContext } from "../../Context/UserContext.tsx";
import { Link, useNavigate } from "react-router-dom";

function SignupForm() {
  const navigate = useNavigate();
  const login= useUserContext()?.login;
  const signupForm = strings?.signupForm;
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [phone, setPhone] = useState<string>("");
  const [fullName, setFullName] = useState<string>("");
    const [error, setError] = useState<string>("");
    const [showError, setShowError] = useState<boolean>(false);
    let emailUnique: boolean = false;

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
    if (!!error) {
      setShowError(false);
    }
  };

  const navigateToMenu = () => {
    navigate("/");
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
    if (!!error) {
      setShowError(false);
    }
  };

  const handlePhoneChange = (event) => {
    setPhone(event.target.value);
    if (!!error) {
      setShowError(false);
    }
  };

  const handleFullnameChange = (event) => {
    setFullName(event.target.value);
    if (!!error) {
      setShowError(false);
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (!isValidFullName(fullName)) {
      return;
    }
    if (!isValidPhoneNumber(phone)) {
      return;
    }
    if (!isValidEmail(email)) {
      return;
    }
    if (!isValidPassword(password)) {
      return;
      }
      await fetchEmailIsUnique()
      if (emailUnique) {
          await    fetchAddCustomer()
          await login(email);
      navigateToMenu();
    } else {
      setError("Данный email уже занят");
      setShowError(true);
    }
  };

  const isValidPhoneNumber = (phone) => {
    if (phone.length <= 0) {
      setError(signupForm.error.phoneEmptyError);
      setShowError(true);
      return false;
    }
    const phoneNumberDigits = phone.replace(/\D/g, ""); // Удаляем все нецифровые символы
    if (phoneNumberDigits.length !== 10) {
      setError(signupForm.error.phoneWrongFormatError);
      setShowError(true);
      return false;
    }
    return true;
  };

  const isValidEmail = (email): boolean => {
    if (email.length <= 0) {
      setError(signupForm.error.emailEmptyError);
      setShowError(true);
      return false;
    }
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const emailIsValid: boolean = emailRegex.test(email);
    if (!emailIsValid) {
      setError(signupForm.error.emailWrongFormatError);
      setShowError(true);
      return false;
    }

    return true;
  };

  const isValidPassword = (password): boolean => {
    if (password.length <= 0) {
      setError(signupForm.error.passwordEmptyError);
      setShowError(true);
      return false;
    }
    return true;
    };

    const fetchEmailIsUnique = async () => {
        try {
            const data = await emailIsUnique(email);
            emailUnique = data;
        } catch (error) {
            console.error("Ошибка при получении об уникальности email:", error);
        }
    };

    const fetchAddCustomer = async () => {
        try {
            await addCustomer(fullName.split(" ")[0], fullName.split(" ")[1], email, phone, password);
        } catch (error) {
            console.error("Ошибка при добавлении покупателя:", error);
        }
    };

  const isValidFullName = (fullName) => {
    if (fullName.length === 0) {
      setError(signupForm.error.fullNameEmptyError);
      setShowError(true);
      return false;
    }
    const words = fullName.trim().split(/\s+/);
    if (words.length !== 2) {
      setError(signupForm.error.fullNameWrongFormatError);
      setShowError(true);
      return false;
    }
    return true;
  };

  return (
    <div className="centered-container" contentEditable={false}>
      <div className="auth-form">
        <form onSubmit={handleSubmit}>
          <h1>{signupForm.registration}</h1>
          <input
            className="input-field"
            value={fullName}
            onChange={handleFullnameChange}
            placeholder={signupForm.enterYourFullname}
          />
          <input
            className="input-field"
            value={phone}
            onChange={handlePhoneChange}
            placeholder={signupForm.enterYourPhone}
          />
          <input
            className="input-field"
            value={email}
            onChange={handleEmailChange}
            placeholder={signupForm.enterYourEmail}
          />
          <input
            className="input-field"
            value={password}
            onChange={handlePasswordChange}
            placeholder={signupForm.enterYourPassword}
          />
          <div className={`error-message ${showError ? "visible" : ""}`}>
            {error}
          </div>
          <button type="submit" className="submit-button">
            {signupForm.signUp}
          </button>
          <p className="link-container">
            <label>{signupForm.haveAccount} </label>
            <Link to="/login">{signupForm.signIn}</Link>
          </p>
        </form>
      </div>
    </div>
  );
}

export default SignupForm;
