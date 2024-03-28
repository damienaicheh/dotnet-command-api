variable "application" {
  description = "Azure deployment application"
  type        = string
  default     = "cmd"
}

variable "environment" {
  description = "The environment deployed"
  type        = string
  default     = "dev"
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