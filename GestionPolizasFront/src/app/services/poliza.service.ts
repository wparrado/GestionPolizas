import { PolicyModel } from './../policy-model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PolizaService {

  constructor(private http: HttpClient) { }
  url = 'https://localhost:44326/api/Poliza';

  getPolices() {
      return this.http.get(this.url);
  }

  createPolicy(policy: PolicyModel): Observable<PolicyModel> {
    return this.http.post<PolicyModel>(this.url, policy);
  }

  updatePolicy(policy: PolicyModel): Observable<PolicyModel> {
    return this.http.patch<PolicyModel>(this.url, policy);
  }
}
