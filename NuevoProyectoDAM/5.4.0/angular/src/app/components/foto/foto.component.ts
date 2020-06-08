import { Component } from "@angular/core";
import { UsuarioLogadoServiceProxy } from "@shared/service-proxies/service-proxies";

class ImageSnippet {
    constructor(public src: string, public file: File) {}
  }
  
  @Component({
    selector: 'app-foto',
    templateUrl: 'foto.component.html',
    styleUrls: ['foto.component.css']
  })
  
  export class FotoComponent {
  
    selectedFile: ImageSnippet;
    hola: string ="";
  
    constructor(private imageService: UsuarioLogadoServiceProxy){}
  
    processFile(imageInput: any) {
      const file: File = imageInput.files[0];
      const reader = new FileReader();
  
      reader.addEventListener('load', (event: any) => {
  
        this.selectedFile = new ImageSnippet(event.target.result, file);
        
        console.log("Nombre de la imagen :" + this.selectedFile.file.name);

        this.imageService.uploadFoto(this.selectedFile.file).subscribe(
          (res) => {
           this.hola = res;
           
          },
          (err) => {
          
          })
      });
  
      reader.readAsDataURL(file);
    }
  }