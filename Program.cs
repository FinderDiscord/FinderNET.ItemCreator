﻿using FinderNET.ItemCreator.Enums;
using FinderNET.ItemCreator.Models;
using Spectre.Console;
using Newtonsoft.Json;

namespace FinderNET.ItemCreator {
    public static class Program {
        public static void Main(string[] args) {
            AnsiConsole.MarkupLine("[blue]Welcome to Finder ItemCreator[/]");
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[aqua]Select an option[/]")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Create new Item", "Exit"
                    })
            );
            switch (option) {
                case "Create new Item":
                    CreateItem();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[blue]Exiting[/]");
                    break;
            }
        }
        private static void DeleteItem() {
            throw new NotImplementedException();
        }
        private static void EditItem() {
            throw new NotImplementedException();
        }
        private static void CreateItem() {
            string name = AnsiConsole.Prompt(new TextPrompt<string>("[aqua]Enter the name of the item[/] [purple](string)[/]"));
            string description = AnsiConsole.Prompt(new TextPrompt<string>("[aqua]Enter the description of the item[/] [purple](string)[/]"));
            int buyprice = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Enter the buy price of the item[/] [purple](integer)[/]"));
            int sellPrice = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Enter the sell price of the item[/] [purple](integer)[/]"));
            string buyableStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[aqua]Is the item buyable[/] [purple](boolean)[/]")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Yes", "No"
                    })
            );
            bool buyable = buyableStr == "Yes";
            string sellableStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[aqua]Is the item sellable[/] [purple](boolean)[/]")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Yes", "No"
                    })
            );
            bool sellable = sellableStr == "Yes";
            string tradableStr = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[aqua]Is the item tradable[/] [purple](boolean)[/]")
                .PageSize(3)
                .MoreChoicesText("[green]More choices[/]")
                .AddChoices( new[] { "Yes", "No" }));
            bool tradable = tradableStr == "Yes";
            ItemRarity rarity = AnsiConsole.Prompt(new SelectionPrompt<ItemRarity>()
                .Title("[aqua]Select the rarity of the item[/] [purple](enum)[/]")
                .AddChoices(new[] {
                    ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Rare, ItemRarity.Epic, ItemRarity.Legendary
                }));

            var item = new Items() {
                Id = Guid.NewGuid(),
                name = name,
                description = description,
                buyPrice = buyprice,
                sellPrice = sellPrice,
                buyable = buyable,
                sellable = sellable,
                tradeable = tradable,
                rarity = rarity
            };
            AnsiConsole.MarkupLine("[blue]Item created![/]");
            string json = JsonConvert.SerializeObject(item);
            AnsiConsole.MarkupLine("[blue]Item JSON:[/]");
            AnsiConsole.MarkupLine(json);
        }
    }
}