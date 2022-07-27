import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any;

  constructor(private http: HttpClient) {}

  public GetEventos(): void {
    this.http.get('http://localhost:5000/api/Evento').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
    this.eventos = [
      {
        nome: 'Angular',
        estado: 'São Paulo',
        cidade: 'SP',
        local: 'EAD'
      },
      {
        nome: '.NET',
        estado: 'São Paulo',
        cidade: 'SP',
        local: 'Terminal Varginha'
      },
      {
        nome: 'EF 5',
        estado: 'São Paulo',
        cidade: 'SP',
        local: 'EAD'
      }
    ];
  }
  ngOnInit(): void {
    this.GetEventos();
  }

}
