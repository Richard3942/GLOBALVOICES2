(function() {
    var inicio = {
        loadInfo: function () {
            inicio.validarForm();
            
        },
        validarForm: function () {
            console.log('en validacion');
            $('form').bootstrapValidator({
               // framework: 'bootstrap',
                feedbackIcons: {
                    valid: "glyphicon glyphicon-ok",
                    invalid: "glyphicon glyphicon-remove",
                    validating: "glyphicon glyphicon-refresh"
                },
                fields: {
                    Nombres: {

                        validators: {
                            notEmpty: {
                                message: "Nombres es obligatorio"
                            },
                            regexp: {
                                regexp: /^[a-z\s]+$/i,
                                message: 'Solo se permiten letras'
                            }
                        }
                    },
                    ModApellidoPaterno: {

                        validators: {
                            notEmpty: {
                                message: "Apellido paterno es obligatorio"
                            },
                            regexp: {
                                regexp: /^[a-z\s]+$/i,
                                message: 'Solo se permiten letras'
                            }
                        }
                    },
                    ModApellidoMaterno: {

                        validators: {
                            notEmpty: {
                                message: "Apellido Materno es obligatorio"
                            },
                            regexp: {
                                regexp: /^[a-z\s]+$/i,
                                message: 'Solo se permiten letras'
                            }
                        }
                    },
                    ModNroDocumento: {
                        validators: {
                            notEmpty: {
                                message: "Nro. Documento es obligatorio"
                            },
                            numeric: {
                                message: 'Solo se permiten números'
                            },
                            stringLength: {
                                message: 'Debe contener 8 digitos',
                                max: 8,
                                min: 8
                            }
                        }
                    },
                    ModCelular: {
                        validators: {
                            notEmpty: {
                                message: "Celular es obligatorio"
                            },
                            numeric: {
                                message: 'Solo se permiten números'
                            },

                        }
                    },

                    ModTelefono: {
                        validators: {
                            numeric: {
                                message: 'Solo se permiten números'
                            },
                            //phone: {
                            //     message: 'el formato del teléfono es incorrecto'
                            //}
                        }
                    },
                    ModEmail: {
                        validators: {
                            notEmpty: {
                                message: "Email es obligatorio"
                            },
                            emailAddress:
                            {
                                message: 'El formato de email es incorrecto'
                            }
                        }
                    },
                    ModFechaNacimiento: {
                        validators: {
                            notEmpty: {
                                message: "Email es obligatorio"
                            },
                            date: {
                                message: 'The date is not valid',
                                format: 'DD/MM/YYYY',
                                // min and max options can be strings or Date objects
                                //min:'01/01/2000',
                                max: "01/01/2000",

                                separator: '/'
                                //min: '2000/01/01',
                                //max: '2020/12/30'
                            }

                        }
                    },

                    ModPaisSeleccionado: {
                        validators: {
                            notEmpty: {
                                message: "Pais es obligatorio"
                            },


                        }
                    },
                    ModCiudad: {
                        validators: {
                            notEmpty: {
                                message: "Ciudad es obligatorio"
                            },
                            regexp: {
                                regexp: /^[a-z\s]+$/i,
                                message: 'Solo se permiten letras'
                            }

                        }
                    },



                }

            });


        }
     
    };
    inicio.loadInfo();
})(jQuery);
