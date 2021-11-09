using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Grids;

namespace Custom_Validation.Data
{
    public class MyCustomValidator : ComponentBase
    {
        [Parameter]
        public ValidatorTemplateContext context { get; set; }

        private ValidationMessageStore messageStore;

        WeatherForecastService Service = new WeatherForecastService();

        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            messageStore = new ValidationMessageStore(CurrentEditContext);

            CurrentEditContext.OnValidationRequested += ValidateRequested;
            CurrentEditContext.OnFieldChanged += ValidateField;
        }
        protected void HandleValidation(FieldIdentifier identifier)
        {
            //validate your requirment column
            if (identifier.FieldName.Equals("Duration"))
            {
                messageStore.Clear(identifier);

                if ((context.EditContext.Model as Tree).Duration < 0)
                {
                    messageStore.Add(identifier, "Duration value should be greater than 0");
                    //context.ShowValidationMessage("Duration", false, "Duration value should be greater than 0");
                }
                else if ((context.EditContext.Model as Tree).Duration > 30)
                {
                    messageStore.Add(identifier, "Duration value should be less than 30");
                    //context.ShowValidationMessage("Duration", false, "Duration value should be less than 30");
                }
                else
                {
                    messageStore.Clear(identifier);
                    context.ShowValidationMessage("Duration", true, null);
                }
            }
            //if (identifier.FieldName.Equals("Priority"))
            //{
            //    messageStore.Clear(identifier);

            //    if ((context.EditContext.Model as Tree).Priority.Length <= 0)
            //    {
            //        messageStore.Add(identifier, "Priority should not be empty value");
            //        //context.ShowValidationMessage("Priority", false, "Priority length value should be greater than 0");
            //    }
            //    else
            //    {
            //        messageStore.Clear(identifier);
            //        //context.ShowValidationMessage("Priority", true, null);
            //    }
            //}
        }
        protected void ValidateField(object editContext, FieldChangedEventArgs fieldChangedEventArgs)
        {
            HandleValidation(fieldChangedEventArgs.FieldIdentifier);
        }
        private void ValidateRequested(object editContext, ValidationRequestedEventArgs validationEventArgs)
        {
            //here call the field you want to validate

            string[] fields = new string[] { "Duration" };

            foreach (var field in fields)
            {
                HandleValidation(CurrentEditContext.Field(field));
            }
        }

    }
}
