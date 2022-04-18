using FluentValidation.Results;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Redacao.Application.Helpers
{
    public static class ResponseReturnHelper<T> where T : class
    {
        public static ResponseViewModel<T> GerarRetorno(Exception ex)
        {
            ResponseViewModel<T> response = new ResponseViewModel<T>();
            response.Data = null;
            response.Message = ex.Message;
            response.HttpStatusCode = HttpStatusCode.InternalServerError;
            response.Paginacao = null;

            return response;
        }

        public static ResponseViewModel<T> GerarRetorno(ValidationResult validationResult)
        {
            ResponseViewModel<T> response = new ResponseViewModel<T>();
            response.Data = null;
            foreach(var erro in validationResult.Errors)
            {
                response.Message += erro.ErrorMessage;
            }
            response.HttpStatusCode = HttpStatusCode.UnprocessableEntity;
            response.Paginacao = null;

            return response;
        }

        public static ResponseViewModel<T> GerarRetorno(HttpStatusCode httpStatusCode, string message, ResponsePaginacao paginacao)
        {
            ResponseViewModel<T> response = new ResponseViewModel<T>();
            response.Data = null;
            response.HttpStatusCode = httpStatusCode;
            response.Message = message;
            response.Paginacao = paginacao;

            return response;
        }

        public static ResponseViewModel<T> GerarRetorno(HttpStatusCode httpStatusCode, string message)
        {
            ResponseViewModel<T> response = new ResponseViewModel<T>();
            response.Data = null;
            response.HttpStatusCode = httpStatusCode;
            response.Message = message;
            response.Paginacao = null;

            return response;
        }

        public static ResponseViewModel<T> GerarRetorno(HttpStatusCode httpStatusCode, T data, string message, ResponsePaginacao paginacao)
        {
            ResponseViewModel<T> response = new ResponseViewModel<T>();
            response.Data = data;
            response.HttpStatusCode = httpStatusCode;
            response.Message = message;
            response.Paginacao = paginacao;

            return response;
        }

        public static ResponseViewModel<T> GerarRetorno(HttpStatusCode httpStatusCode, T data, string message)
        {
            ResponseViewModel<T> response = new ResponseViewModel<T>();
            response.Data = data;
            response.HttpStatusCode = httpStatusCode;
            response.Message = message;
            response.Paginacao = null;

            return response;
        }
    }
}
