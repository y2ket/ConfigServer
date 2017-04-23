﻿import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { ResourceInfo } from '../interfaces/resourceInfo';
import 'rxjs/add/operator/toPromise';
import { IHttpRequestResult } from '../interfaces/httpRequestResult';
@Injectable()
export class GuidGenerator {
    constructor(private http: Http) { }

    getGuid(): Promise<string> {
        return this.http.post('GenerateGuid', null)
            .toPromise()
            .then(response => response.json() as string)
            .catch(this.handleError);
    }

    private handlePostSuccess(response: Response) {
        return {
            suceeded: true
        };
    }
    private handleError(error: any): Promise<any> {
        // console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }
}