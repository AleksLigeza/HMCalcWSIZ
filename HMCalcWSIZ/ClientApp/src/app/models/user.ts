export class User {
    id: string;
    email: string;
    password: string;

    static copy(pattern: User): User {
        const temp = new User();
        temp.email = pattern.email;
        temp.password = pattern.password;
        temp.id = pattern.id;
        return temp;
    }
}
