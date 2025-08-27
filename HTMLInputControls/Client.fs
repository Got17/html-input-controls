namespace HTMLInputControls

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating

[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>

    let radioGroup : Var<string> = Var.Create ""

    [<SPAEntryPoint>]
    let Main () =

        IndexTemplate.Main()
            .PickA(fun _ -> radioGroup.Set "A")
            .PickB(fun _ -> radioGroup.Set "B")
            .PickC(fun _ -> radioGroup.Set "C")
            .SubmitForm(fun e ->
                e.Event.PreventDefault()

                let v = e.Vars

                Console.Log("[Textual]")
                Console.Log("TextInput:", v.TextInput.Value)
                Console.Log("Textarea:", v.Textarea.Value)
                Console.Log("Password:", v.Password.Value)
                Console.Log("Email:", v.Email.Value)
                Console.Log("Url:", v.Url.Value)
                Console.Log("Tel:", v.Tel.Value)
                Console.Log("Search:", v.Search.Value)

                Console.Log("[Numbers & Ranges]")
                Console.Log("Number:", v.Number.Value)
                Console.Log("Range:", v.Range.Value)

                Console.Log("[Dates & Times]")
                Console.Log("Date:", v.Date.Value)
                Console.Log("Time:", v.Time.Value)
                Console.Log("DatetimeLocal:", v.DatetimeLocal.Value)
                Console.Log("Month:", v.Month.Value)
                Console.Log("Week:", v.Week.Value)

                Console.Log("[Choices]")
                Console.Log("SelectSingle:", v.SelectSingle.Value)

                Console.Log("SelectMulti:", String.concat ", " v.SelectMulti.Value )
                Console.Log("RadioGroup:", radioGroup.Value)

                Console.Log("Chk1:", v.Chk1.Value)
                Console.Log("Chk2:", v.Chk2.Value)
                Console.Log("DatalistInput:", v.DatalistInput.Value)

                Console.Log("Color:", v.Color.Value)
            )
            .Doc()
        |> Doc.RunById "main"
