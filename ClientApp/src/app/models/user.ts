export interface User {
  userId: string;
  email: string;
  countryId?: string;
  provinceId?: string;
  accessToken?: string;
}

export interface AuthRequest {
  email: string;
  password: string;
}

export interface CreateUserRequest {
  email: string;
  password: string;
  countryId: string;
  provinceId: string;
}
