import React, { useState } from "react";
import strings from "../resources/ResourcesStrings";
import "./ProfilEditor.css";
import { emailIsUnique, editUser } from "../services/dataService.ts";
import { useUserContext } from "../Context/UserContext.tsx";
import { IUserType } from "../types.ts";


export interface IProfilEditorProps {
  user: IUserType;
}

function ProfilEditor(props: IProfilEditorProps) {
  const login = useUserContext()?.login;
  const signupForm = strings?.signupForm;
    const user = useUserContext()?.user;
    const oldEmail: string = props.user.email;
  const [email, setEmail] = useState<string>(props.user.email);
  const [phone, setPhone] = useState<string>(props.user.phone);
  const [fullName, setFullName] = useState<string>(
    props.user.firstName + " " + props.user.lastName
  );
  const [error, setError] = useState<string>("");
  const [showError, setShowError] = useState<boolean>(false);

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
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

    const fetchEditUser = async () => {
        try {
            await editUser(user?.id, fullName.split(" ")[0], fullName.split(" ")[1], email, phone);
        } catch (error) {
            console.error("Ошибка при получении об уникальности email:", error);
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
      if (oldEmail !== email) {
          if (!isValidEmail(email)) {
              return;
          }
          const emailUnique: boolean = await emailIsUnique(email);
          if (!emailUnique) {
              setError("Данный email уже занят");
              setShowError(true);
          }
      }

      if (user?.id) {
        await  fetchEditUser();
        login(email);
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
    <div className="profil-editor-container" contentEditable={false}>
      <div className="auth-form">
        <form onSubmit={handleSubmit}>
          <h1>Личные данные</h1>
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
          <div className={`error-message ${showError ? "visible" : ""}`}>
            {error}
          </div>
          <button type="submit" className="submit-button">
            Сохранить изменения
          </button>
        </form>
      </div>
    </div>
  );
}

export default ProfilEditor;

