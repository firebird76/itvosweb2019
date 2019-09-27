import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { baseUrl } from 'src/environments/environment';
import { Continent } from '../models';

@Component({
  selector: 'app-continent-list',
  templateUrl: './continent-list.component.html',
  styleUrls: ['./continent-list.component.css']
})
export class ContinentListComponent implements OnInit {

  continents : Continent[];
  countries;

  constructor(private httpClient:HttpClient) { }

  async ngOnInit() {
   this.continents = await this.httpClient.get<Continent[]>(baseUrl).toPromise();
  }

  async loadCountries(continentId:number){
    this.countries=await this.httpClient.get(baseUrl + continentId + '/countries').toPromise();
  }
}
