import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { ConfigService } from '../../shared/utils/config.service';
import { BaseService } from '../../shared/services/base.service';
import { Observable } from 'rxjs/Observable';
import { catchError, map } from 'rxjs/operators';


import { GardenBed } from '../models/gardenbed.interface';

@Injectable()

export class DashboardService extends BaseService {

    baseApiUrl = '';

    constructor(private http: Http, private configService: ConfigService) {
        super();
        this.baseApiUrl = configService.getApiURI();
    }

    getGardenBeds(): Observable<GardenBed[]> {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');
        const authToken = localStorage.getItem('auth_token');
        headers.append('Authorization', `Bearer ${authToken}`);

        return this.http.get(this.baseApiUrl + '/GardenBeds', { headers })
            .pipe(
                map(response => response.json()),
                catchError(this.handleError)
            );
    }
}
