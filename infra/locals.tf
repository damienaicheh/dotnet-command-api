locals {
  resource_suffix           = [lower(var.environment), lower(var.region), substr(lower(var.application), 0, 3), random_id.resource_group_name_suffix.hex]
  resource_suffix_kebabcase = join("-", local.resource_suffix)

  tags = merge(
    var.tags,
    tomap(
      {
        "azd-env-name" = var.environment,
        "Environment"  = var.environment,
        "ProjectName"  = "dotner-command-api",
        "Application"  = var.application
      }
    )
  )
}
