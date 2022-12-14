<script>
export default {
    props: {
        id: String,
        label: String,
        type: String,
        placeholder: String,
        rows: String,
        modelValue: String,
    },
    emits: ["update:modelValue"],
    methods: {
        onInput(e) {
            this.$emit("update:modelValue", e.target.value)
        }
    }
}
</script>

<template>
    <div class="input-wrapper">
        <label :for="id">{{ this.label }}</label>
        <textarea :rows="rows" :value="modelValue" @input="onInput" :placeholder="placeholder"
            v-if="type === 'textarea'"></textarea>
        <input v-else :id="id" :value="type === 'file' ? '' : modelValue" @input="onInput" :type="type"
            :placeholder="placeholder">
    </div>

</template>

<style scoped>
.input-wrapper {
    display: flex;
    padding: 12px;
    flex-direction: column;
}

textarea {
    background: #fff;
    border: 3px solid var(--purple);
    border-radius: 10px;
    color: black;
    width: 100%;
    padding: 12px;
    outline: 0;
    font-family: inherit;
    font-size: 1em;
    resize: vertical;
    min-height: 100px;
    max-height: 50vh;
}

label {
    margin-right: 24px;
    margin-bottom: 12px;
    vertical-align: middle;
    width: 20%;
}

input {
    width: 80%;
    padding: 12px;
    outline: 0;
    font-family: inherit;
    font-size: 1em;
}

input[type="email"],
input[type="password"],
input[type="text"],
input[type="date"] {
    background: #fff;
    border: 3px solid var(--purple);
    border-radius: 10px;
    color: black;
}

input[type="email"]:focus,
input[type="password"]:focus,
input[type="text"]:focus {
    border-color: #8338ec;
}

input[type="file"] {
    display: none;
}
</style>