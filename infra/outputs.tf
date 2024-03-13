output "AZURE_LOCATION" {
  value = var.location
}

output "AZURE_TENANT_ID" {
  value = data.azurerm_client_config.current.tenant_id
}

output "APP_SERVICE_URL" {
  value = azurerm_linux_web_app.this.default_hostname
}

output "AZURE_RESOURCE_GROUP" {
  value = azurerm_resource_group.this.name
}