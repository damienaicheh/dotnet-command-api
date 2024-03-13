variable "application" {
  description = "Azure deployment application"
  type        = string
  default     = "cmd"
}

variable "environment" {
  description = "The environment deployed"
  type        = string
  default     = "dev"
  validation {
    condition     = can(regex("(pr|dev|stg|pro)", var.environment))
    error_message = "The environment value must be a valid."
  }
}

variable "location" {
  description = "Azure deployment location"
  type        = string
  default     = "westeurope"
}

variable "region" {
  description = "Azure deployment region"
  type        = string
  default     = "euw"
}

variable "tags" {
  type        = map(any)
  description = "The custom tags for all resources"
  default     = {}
}