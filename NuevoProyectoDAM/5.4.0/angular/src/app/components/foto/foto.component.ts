import { IAjaxResponse } from '@abp/abpHttpInterceptor';
import { TokenService } from '@abp/auth/token.service';
import { Component, Injector, ViewChild } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/app-component-base';
//import { UserServiceProxy, UpdateProfilePictureInput } from '@shared/service-proxies/service-proxies';
//import { FileUploader, FileUploaderOptions } from 'ng2-file-upload';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';




@Component({
  selector: 'app-foto',
  templateUrl: './foto.component.html',
  styleUrls: ['./foto.component.css']
})



export class FotoComponent extends AppComponentBase {

   // @ViewChild('changeProfilePictureModal') modal: ModalDirective;

    public active = false;
   // public uploader: FileUploader;
    public temporaryPictureUrl: string;
    public saving = false;

    private maxProfilPictureBytesUserFriendlyValue = 5;
    private temporaryPictureFileName: string;
  //  private _uploaderOptions: FileUploaderOptions = {};

    constructor(
        injector: Injector,
       // private _profileService: ProfileServiceProxy,
        private _tokenService: TokenService
    ) {
        super(injector);
    }

    /*initializeModal(): void {
        this.active = true;
        this.temporaryPictureUrl = '';
        this.temporaryPictureFileName = '';
        this.initFileUploader();
    }

    show(): void {
        this.initializeModal();
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.imageChangedEvent = '';
        this.uploader.clearQueue();
        this.modal.hide();
    }

    imageChangedEvent: any = '';

    fileChangeEvent(event: any): void {
        this.imageChangedEvent = event;
    }

    imageCroppedFile(file: File) {
        var files: File[] = [file];
        this.uploader.clearQueue();
        this.uploader.addToQueue(files);
    }

    initFileUploader(): void {
        this.uploader = new FileUploader({ url: "http://localhost:22742/Profile/UploadProfilePicture' });
        this._uploaderOptions.autoUpload = false;
        this._uploaderOptions.authToken = 'Bearer ' + this._tokenService.getToken();
        this._uploaderOptions.removeAfterUpload = true;
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            const resp = <IAjaxResponse>JSON.parse(response);
            if (resp.success) {
                this.updateProfilePicture(resp.result.fileName);
            } else {
                this.message.error(resp.error.message);
            }
        };

        this.uploader.setOptions(this._uploaderOptions);
    }

    updateProfilePicture(fileName: string): void {
        const input = new UpdateProfilePictureInput();
        input.fileName = fileName;
        input.x = 0;
        input.y = 0;
        input.width = 0;
        input.height = 0;

        this.saving = true;
        this._profileService.updateProfilePicture(input)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                abp.event.trigger('profilePictureChanged');
                this.close();
            });
    }

    save(): void {
        this.uploader.uploadAll();
    }
*/}