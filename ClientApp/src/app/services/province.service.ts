import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Province } from "../models/province";
import {environment} from "../environments/environment";


@Injectable({ providedIn: 'root' })
export class ProvinceService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Province[]>(`${environment.apiUrl}/provinces`);
  }
}
