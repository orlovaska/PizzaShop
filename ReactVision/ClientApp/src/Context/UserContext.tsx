import React, { createContext, useContext, useState, ReactNode } from 'react';
import { getUserByEmail } from "../services/dataService.ts";
import { IUserType } from './types';

interface IUserContext {
    user: IUserType | null;
    login: (email: string) => void; 
    logout: () => void;
}

const user: IUserType = { 
  id: 1,
  firstName: "Yakow",
  lastName: "Orlov",
  phone: "1234567890",
  email: "yacha@example.com",
};

export const UserContext = createContext<IUserContext>({
    user: null,
    login: () => { },
    logout: () => { },
});

export const useUserContext = () => {
  const context = useContext(UserContext);
  return context;
};

interface UserProviderProps {
  children: ReactNode;
}

export function UserProvider({ children }: UserProviderProps) {
    const [user, setUser] = useState<IUserType | null>(null);

    const fetchUser = async (email: string) => {
        try {
            const fetchedUser = await getUserByEmail(email);
            setUser(fetchedUser);
        } catch (error) {
            console.error("Ошибка при загрузке пользователя: ", error);
        }
    };

    const login = async (email: string) => {
        await fetchUser(email);
    };

  const logout = () => {
    setUser(null);
  };

  const userContextValue: IUserContext = {
    user,
    login,
    logout,
  };

  return (
    <UserContext.Provider value={userContextValue}>
      {children}
    </UserContext.Provider>
  );
};
