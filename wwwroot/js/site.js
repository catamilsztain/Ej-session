// Validación del formulario de registro (view: Registrarse)
const USERNAME_MIN = 4;
const PASSWORD_MIN = 6;
const NAME_REGEX = /^[A-Za-zÀ-ÖØ-öø-ÿ' \-]+$/;

document.addEventListener('DOMContentLoaded', () => {
	const form = document.querySelector('form');
	if (!form) return;

	form.addEventListener('submit', (e) => {
		const get = (name) => (form.elements[name] ? form.elements[name].value.trim() : '');
		const username = get('NombreUsuario');
		let password = '';
		const passElemById = document.getElementById('Contrasena');
		if (passElemById && passElemById.value !== undefined) {
			password = passElemById.value.trim();
		} else {
			password = (form.elements['Contraseña'] ? form.elements['Contraseña'].value : '').trim();
		}
		const nombre = get('Nombre');
		const apellido = get('Apellido');

		const errors = [];

		if (!username) errors.push('El campo Usuario es obligatorio.');
		else if (username.length < USERNAME_MIN) errors.push(`El usuario debe tener al menos ${USERNAME_MIN} caracteres.`);

		if (!password) errors.push('El campo Contraseña es obligatorio.');
		else if (password.length < PASSWORD_MIN) errors.push(`La contraseña debe tener al menos ${PASSWORD_MIN} caracteres.`);

		if (!nombre) errors.push('El campo Nombre es obligatorio.');
		else if (!NAME_REGEX.test(nombre)) errors.push('El Nombre contiene caracteres no válidos.');

		if (!apellido) errors.push('El campo Apellido es obligatorio.');
		else if (!NAME_REGEX.test(apellido)) errors.push('El Apellido contiene caracteres no válidos.');

		const errorContainer = form.querySelector('#register-errors') || createErrorContainer();

		if (errors.length) {
			e.preventDefault();
			renderErrors(errorContainer, errors);
		} else {
			renderErrors(errorContainer, []);
		}
	});

	function createErrorContainer() {
		const div = document.createElement('div');
		div.id = 'register-errors';
		div.className = 'validation-errors';
		div.style.color = '#b00020';
		div.style.marginBottom = '10px';
		form.insertBefore(div, form.firstChild);
		return div;
	}

	function renderErrors(container, errors) {
		if (!container) return;
		if (!errors || errors.length === 0) {
			container.innerHTML = '';
			container.style.display = 'none';
			return;
		}
		container.style.display = 'block';
		container.innerHTML = '<ul style="margin:0;padding-left:20px;">' + errors.map(e => `<li>${escapeHtml(e)}</li>`).join('') + '</ul>';
	}

	function escapeHtml(str) {
		return str.replace(/[&<>\"']/g, function (c) {
			return {'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":"&#39;"}[c];
		});
	}
});
