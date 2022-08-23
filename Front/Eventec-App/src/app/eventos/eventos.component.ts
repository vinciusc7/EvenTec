import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventosFiltrados: any = [];
  public eventos: any = [];
  widthIMG: number = 70;
  marginIMG: number = 2;
  showIMG: boolean = true;
  isCollapsed = true;
  private _filtroLista: string = '';

  public get filtroLista (): string {
    return this._filtroLista;
  }

  public set filtroLista (value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista ) : this.eventos;
  }

  filtrarEventos (filtrarPor: string){
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  updateImg() {
    this.showIMG = !this.showIMG;
  }
  constructor(private http: HttpClient) {}

  public GetEventos(): void {
    this.http.get('http://localhost:5000/api/Evento').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );

  }
  ngOnInit(): void {
    this.GetEventos();
  }

}
