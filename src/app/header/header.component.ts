import { Component, OnInit, NgModule, OnDestroy } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs/Subscription';
import { UserService } from '../shared/services/user.service';

@NgModule({
    imports: [NgbModule]
})

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

    isCollapsed: boolean;
    status: boolean;
    subscription: Subscription;

    constructor(private userService: UserService) {
        this.isCollapsed = true;
    }

    title = 'ICarufy Garden Manager';

    logout() {
        this.userService.logout();
    }

    ngOnInit() {
        this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
    }

    ngOnDestroy(): void {
        // prevent memory leak when component is destroyed
        this.subscription.unsubscribe();
    }
}
