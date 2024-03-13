resource "azurerm_service_plan" "this" {
  name                = format("asp-%s", local.resource_suffix_kebabcase)
  resource_group_name = azurerm_resource_group.this.name
  location            = var.location
  os_type             = "Linux"
  sku_name            = "B1"
  tags                = local.tags
}

resource "azurerm_linux_web_app" "this" {
  name                = format("app-%s", local.resource_suffix_kebabcase)
  resource_group_name = azurerm_resource_group.this.name
  location            = var.location
  service_plan_id     = azurerm_service_plan.this.id
  tags = merge(
    var.tags,
    tomap({
      "azd-service-name" = "api"
    })
  )

  identity {
    type = "SystemAssigned"
  }

  site_config {
    application_stack {
      dotnet_version = "8.0"
    }
  }

  app_settings = {
    "USE_DATABASE" = "false"
  }
}
