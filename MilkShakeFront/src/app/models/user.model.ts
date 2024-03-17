export class User {
    userId!: number;
    username!: string;
    email!: string;
    passwordHash!: string;
    firstName!: string;
    lastName!: string;
    dateOfBirth!: Date;
    createdAt!: Date;
    updatedAt!: Date;
  
    constructor(data?: any) {
      if (data) {
        this.userId = data.userId ?? 0;
        this.username = data.username ?? '';
        this.email = data.email ?? '';
        this.passwordHash = data.passwordHash ?? '';
        this.firstName = data.firstName ?? '';
        this.lastName = data.lastName ?? '';
        this.dateOfBirth = data.dateOfBirth ?? new Date(data.dateOfBirth);
        this.createdAt = data.createdAt ?? new Date(data.createdAt);
        this.updatedAt = new Date(data.updatedAt);
      }
    }
  }