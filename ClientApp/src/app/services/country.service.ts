import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Country } from "../models/country";
import {environment} from "../environments/environment";


@Injectable({ providedIn: 'root' })
export class CountryService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Country[]>(`${environment.apiUrl}/countries`);
  }
}
