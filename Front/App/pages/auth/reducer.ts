import {combineReducers} from "redux";
import {ActionType, getType} from "typesafe-actions";
import {authActions} from "./";
import {LS_KEY_TOKEN} from "../../api/api-base";

export type AuthAction = ActionType<typeof authActions>;

export type AuthState = Readonly<{
    token: string;
    email: string;
    isLoggedIn: boolean;
}>;

export default combineReducers<AuthState, AuthAction>({
    token: (token: string = getToken(), action: any) => {
        switch (action.type) {
            case getType(authActions.updateToken):
                setToken(action.payload);
                return action.payload;

            case getType(authActions.logout):
                removeToken();
                return null;

            default:
                return token;
        }
    },
    isLoggedIn: (isLoggedIn: boolean = isTokenExists(), action: any) => {
        switch (action.type) {
            case getType(authActions.updateToken):
                return true;

            case getType(authActions.logout):
                return false;

            default:
                return isLoggedIn;
        }
    },
    email: (email: string = "guest", action: any) => {
        switch (action.type) {
            case getType(authActions.updateEmail):
                return action.payload;

            case getType(authActions.logout):
                return "guest";

            default:
                return email;
        }
    }
});

function isTokenExists(): boolean {
    return getToken() != null;
}

function getToken(): string {
    return localStorage.getItem(LS_KEY_TOKEN) || null;
}

function setToken(token: string): void {
    localStorage.setItem(LS_KEY_TOKEN, token);
}

function removeToken() {
    localStorage.removeItem(LS_KEY_TOKEN)
}