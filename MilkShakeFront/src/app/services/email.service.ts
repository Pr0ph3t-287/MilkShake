import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmailService {
  private apiUrl = `${environment.apiEndpoint}/api/email`;

  constructor(private http: HttpClient) { }

  sendEmailWithAttachment(emailAddress: string, pdfFile: FormData): Observable<any> {
    const formData = pdfFile;
    formData.append('emailAddress', emailAddress);

    return this.http.post<any>(`${this.apiUrl}`, formData);
  }
}
