import React, { useState } from "react";
import strings from "../../../resources/ResourcesStrings.js";
import "./LoginForm.css";
import { useUserContext } from "../../../Context/UserContext.tsx";
import { passwordVerification } from "../../../services/dataService.ts";
import { Link, useNavigate } from "react-router-dom";

function LoginForm() {
  const navigate = useNavigate();
  const login = useUserContext()?.login;
  const loginForm = strings?.loginForm;
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [showError, setShowError] = useState<boolean>(false);
    const [error, setError] = useState<string>("");
    let verificationSuccess: boolean = false;

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
    if (!!error) {
      setShowError(false);
    }
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
    if (!!error) {
      setShowError(false);
    }
    };

    const fetchPasswordVerification = async () => {
        try {
            const data = await passwordVerification(email, password);
            verificationSuccess = data;
        } catch (error) {
            console.error("Ошибка при получения ответа верефикации:", error);
        }
    };

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (!isValidEmail(email)) {
      return;
    }
    if (!isValidPassword(password)) {
      return;
    }
      await fetchPasswordVerification()
      if (verificationSuccess) {
          await login(email);
      navigate("/");
    } else {
        setError(loginForm.error.wrongLoginOrPassword);
        setShowError(true);
    }
  };

  const isValidEmail = (email): boolean => {
    if (email.length <= 0) {
      setError(loginForm.error.emailEmptyError);
      setShowError(true);
      return false;
    }
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const emailIsValid: boolean = emailRegex.test(email);
    if (!emailIsValid) {
      setError(loginForm.error.emailWrongFormatError);
      setShowError(true);
    }
    return emailIsValid;
  };

  const isValidPassword = (password): boolean => {
    if (password.length <= 0) {
      setError(loginForm.error.passwordEmptyError);
      setShowError(true);
      return false;
    }
    return true;
  };

  return (
    <div className="centered-container" contentEditable={false}>
      <div className="auth-form">
        <form onSubmit={handleSubmit}>
          <div className="form-container">
            <h1>{loginForm.login}</h1>
            <input
              className="input-field"
              value={email}
              onChange={handleEmailChange}
              placeholder={loginForm.enterYourEmail}
            />
            <input
              className="input-field"
              value={password}
              onChange={handlePasswordChange}
              placeholder={loginForm.enterYourPassword}
            />
            <div className={`error-message ${showError ? "visible" : ""}`}>
              {error}
            </div>
            <button type="submit" className="submit-button">
              {loginForm.signIn}
            </button>
            <p className="link-container">
              <label>{loginForm.noAccount} </label>
              <Link to="/signup">{loginForm.signUp}</Link>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
}

export default LoginForm;
