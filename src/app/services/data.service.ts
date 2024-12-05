import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }



apiJsonLocalGet(url:string){
  let httpRequest = this.http.get(url);
  return httpRequest.pipe(

  );
}

//NewApi

apiGetUser(){


  //this.http.get('http://localhost:5000/UserEF/GetUsers');

  let httpRequest = this.http.get('http://localhost:5000/UserEF/GetUsers');
  return httpRequest.pipe(

  );
}

}
