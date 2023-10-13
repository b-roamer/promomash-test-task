import { Component } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators
} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../services/auth.service";
import {CountryService} from "../../services/country.service";
import {Country} from "../../models/country";
import {Province} from "../../models/province";
import {first} from "rxjs/operators";
import {AuthRequest, CreateUserRequest} from "../../models/user";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  passwordsFormGroup!: FormGroup;

  countries: Country[] = [];
  provinces: Province[] = [];

  isAgree = false;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private countryService: CountryService
  ) {
    if (this.authService.userValue) {
      this.router.navigate(['/']);
    }

    countryService.getAll()
      .pipe(first())
      .subscribe(countries => {
        this.countries = countries;
      });
  }

  get email() {
    return this.firstFormGroup.get('email') as FormControl;
  }

  get password() {
    return this.passwordsFormGroup.get('password') as FormControl;
  }

  get confirmPassword() {
    return this.passwordsFormGroup.get('confirmPassword') as FormControl;
  }

  get countryId() {
    return this.secondFormGroup.get('countryId') as FormControl;
  }

  get provinceId() {
    return this.secondFormGroup.get('provinceId') as FormControl;
  }

  // get provinces() {
  //   return this.countries.filter(x => x.countryId === this.countryId.value)[0]?.provinces || [];
  // }

  // The implementation of getting error messages
  // could be improved further
  getEmailErrors() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  getPasswordErrors() {
    if (this.password.hasError('required')) {
      return 'You must enter a value';
    }

    if (this.password.hasError('pattern')) {
      return 'Must have 6 characters, at least 1 letter and 1 digit';
    }

    return '';
  }

  getConfirmPasswordErrors() {
    if (this.confirmPassword.hasError('required')) {
      return 'Please confirm your password again';
    }

    if (this.confirmPassword.value != this.password.value){
      return 'Passwords do not match';
    }

    return '';
  }

  getCountryErrors() {
    if (this.countryId.hasError('required')) {
      return 'Please select a country';
    }

    return '';
  }

  getProvinceErrors() {
    if (this.provinceId.hasError('required')) {
      return 'Please select a province';
    }

    return '';
  }

  canProceed() {
    return this.isAgree && this.firstFormGroup.valid && this.passwordsFormGroup.valid;
  }

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
    });

    this.passwordsFormGroup = this.formBuilder.group({
      password: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[0-9])(?=.*[a-zA-Z]).{6,}$')]],
      confirmPassword: ['', [Validators.required]],
    });

    this.passwordsFormGroup.addValidators(
      matchValidator(this.passwordsFormGroup.get('password'), this.passwordsFormGroup.get('confirmPassword')));

    this.secondFormGroup = this.formBuilder.group({
      countryId: ['', [Validators.required]],
      provinceId: ['', [Validators.required]]
    });

    this.secondFormGroup.get('countryId')?.valueChanges.subscribe(countryId => {
      this.provinces = this.countries.filter(x => x.countryId === this.countryId.value)[0]?.provinces ?? [];
    });
  }

  onSubmit() {
    if (this.firstFormGroup.invalid || this.passwordsFormGroup.invalid || this.secondFormGroup.invalid) {
      return;
    }

    this.error = '';

    const createUserRequest: CreateUserRequest = {
      email: this.email.value,
      password: this.password?.value,
      countryId: this.countryId.value,
      provinceId: this.provinceId.value
    };

    this.authService.register(createUserRequest)
      .pipe(first())
      .subscribe({
        next: () => {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          this.router.navigate([returnUrl]);
        },
        error: error => {
          this.error = error;
        }
      });
  }
}


function matchValidator(
  password: AbstractControl | null,
  confirmPassword: AbstractControl | null
): ValidatorFn {
  return () => {
    if (password?.value !== confirmPassword?.value)
    {
      confirmPassword?.setErrors({'match_error': true});
      return { match_error: 'Passwords do not match' };
    }
    confirmPassword?.setErrors(null);
    return null;
  };
}
