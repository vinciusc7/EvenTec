import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = [
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
]
  constructor() { }

  ngOnInit(): void {
  }

}
