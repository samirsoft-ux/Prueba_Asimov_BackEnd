Feature: US011
	Como docente
	deseo leer información detallada acerca de las competencias
	para entenderlas mejor
	
	Background:
		Given el docente se encuentra en el menú de la aplicación
		When seleccione el diccionario de competencias
	
	Scenario: Visualiza las competencias
		Then aparecerá una lista de las competencias con sus definiciones.

	Scenario: No existen competencias
		Then aparecerá el mensaje “Actualmente no existen competencias”.

	Scenario: No se puede obtener la información
		Then aparecerá el mensaje “Error interno: no se ha podido acceder a la información”.