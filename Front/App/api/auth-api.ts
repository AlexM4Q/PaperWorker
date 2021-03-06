import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";
import {RoleName} from "../constants/role-name";

export interface AuthData {
    readonly token?: string;
    readonly email: string;
    readonly roles: RoleName[];
}

export default class AuthApi extends ApiBase {

    public static token(email: string, password: string): Promise<AuthData> {
        return fetch(`${this.SERVER_HOST}/api/auth/token`, {
            method: HttpMethod.Post,
            headers: this.DEFAULT_HEADERS,
            body: JSON.stringify({
                email,
                password
            })
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

    public static email(token: string): Promise<AuthData> {
        return fetch(`${this.SERVER_HOST}/api/auth/email`, {
            method: HttpMethod.Get,
            headers: this.authorizedHeaders(token)
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

    public static restorePassword(email: string): Promise<boolean> {
        return fetch(`${this.SERVER_HOST}/api/auth/restore-password`, {
            method: HttpMethod.Post,
            headers: this.DEFAULT_HEADERS,
            body: JSON.stringify(email)
        })
            .then((response: Response) => response.ok);
    }

    public static changePassword(password: string, token?: string): Promise<AuthData> {
        return fetch(`${this.SERVER_HOST}/api/auth/change-password`, {
            method: HttpMethod.Put,
            headers: this.authorizedHeaders(token),
            body: JSON.stringify(password)
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

    public static sendAuthLink(email: string): Promise<boolean> {
        return fetch(`${this.SERVER_HOST}/api/auth/send-auth-link`, {
            method: HttpMethod.Post,
            headers: this.DEFAULT_HEADERS,
            body: JSON.stringify(email)
        })
            .then((response: Response) => response.ok);
    }

    public static register(email: string): Promise<boolean> {
        return fetch(`${this.SERVER_HOST}/api/auth/register`, {
            method: HttpMethod.Post,
            headers: this.DEFAULT_HEADERS,
            body: JSON.stringify(email)
        })
            .then((response: Response) => response.ok);
    }

}