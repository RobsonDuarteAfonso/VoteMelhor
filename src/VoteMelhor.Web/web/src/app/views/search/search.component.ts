import { CommandResult } from './../../models/command-result.model';
import { FormValidations } from './../../components/form-validations';
import { SearchPoliticalService } from '../../services/search/search-political.service';
import { StatesService } from './../../services/shared/states.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { StateBr } from 'src/app/models/state-br.model';
import { Political } from 'src/app/models/political.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private statesService: StatesService,
    private searchPoliticalService: SearchPoliticalService,
  ) { }

  form: FormGroup;
  states: StateBr[];
  politicals: Political[];
  showMsg = false;
  showLoad = false;
  showMsgSearch = false;
  showNotData = false;


  ngOnInit() {

    this.statesService.getStatesBR().subscribe((res: CommandResult) => {
      this.states = res.data;
    });

    this.form = this.formBuilder.group(
      {
        name: [null, [Validators.minLength(3), Validators.maxLength(100)]],
        state: [null]
      },
      {
        validator: FormValidations.atLeastOne()
      }
    );

    // this.form.setValidators(FormValidations.atLeastOne());
  }

  onSubmit() {

    this.showMsg = true;
    this.clearScreen();
    this.showLoad = true;

    if (this.form.valid) {

      this.searchPoliticalService.getSearchPolitical(this.form.value).subscribe(res => {
        this.politicals = res.data;
        this.showLoad = false;

        if (this.politicals == null || this.politicals.length === 0) {
          this.showNotData = true;
        } else {
          this.showNotData = false;
        }
      });
    }
  }

  clearScreen(): void {
    this.politicals = null;
    this.showNotData = false;
  }
}
