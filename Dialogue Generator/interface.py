import gradio as gr
import openai
from default_strings import system_message, character_profiles, background_settings

openai.api_key = "YOUR API KEY HERE"

past_outputs_str = ""
current_output = ""


def generate_dialogue(prompt, system_message=system_message,  character_profiles=character_profiles, background_settings=background_settings, model="gpt-3.5-turbo"):
    sys_message = assemble_prompt(
        system_message, character_profiles, background_settings)
    messages = [
        {"role": "system", "content": sys_message},
        {"role": "user", "content": past_outputs_str+prompt},

    ]
    response = openai.ChatCompletion.create(
        model=model,
        messages=messages,
        temperature=0.1

    )
    set_current_output(response.choices[0].message["content"])
    return response.choices[0].message["content"]


def add_tags_gpt(prompt, system_message=system_message, model="gpt-3.5-turbo"):
    messages = [{"role": "user", "content": prompt}]
    messages = [
        {"role": "system", "content": system_message},
        {"role": "user", "content": prompt},

    ]
    response = openai.ChatCompletion.create(
        model=model,
        messages=messages,
        temperature=0.1

    )
    return response.choices[0].message["content"]


def assemble_prompt(system_message, character_profiles, background_settings):
    return system_message + "The backstory hidden from the player is as follows in triple quotes \n" + '"""\n' + background_settings + '\n"""\n' + "The characters are as  follows: \n" + '"""\n' + character_profiles + '\n"""\n' + """
    You are a screenwriter, your job is to assist me in writing the dialogue for a detective game.You will be given the description of a scene, 
    generate the dialogues for the characters, follow a conversational format, with characters speaking in short sentences or phrases. Each character 
    should have their own unique voice and manner of speaking, adding depth to the dialogue. 

    output each dialogue in the format "Oliver White (Detective): sentence"
    """


def assemble_prompt_one(dialogue):
    return ''' 

        You will be given a piece of dialogue, reformat it into the format below. 


        "{Line}  #speaker: {Speaker} #portrait: {Expression} #layout: {position} "


        Where
        Line: the line spoken by the person, 
        Speaker: the name of the person speaking, add "_" between the first name and last name
        Expression: interpret the speaker's emotion and choose from "neutral", "angry", "thinking", "happy", "sad", "explaining", "shocked"
        Position: choose from "left" or "right"




        The dialogue to format is given in triple quotes below
        """

    ''' + dialogue + '''


        """


        - When a line consists of a few sentences, break it down into a few shorter senteces, keep the tags same.


        For example:
        """
        Yes, Captain. #speaker: Oliver_White #portrait: neutral #layout: left
        However, keep in mind, we're yet to establish this as a murder conclusively. #speaker: Oliver_White #portrait: neutral #layout: left
        We should approach this subtly to avoid alarming potential suspects."  #speaker: Oliver_White #portrait: thinking #layout: left
        """
    '''


def assemble_prompt_two(dialogue):
    return '''
    You will be given a dialogue in triple quotes below, break down the long sentences into short separate sentences with the same tags,  
    reinterpret the #portrait tag by choosing from  "neutral", "angry", "thinking", "happy", "sad", "explaining", "shocked"

    keep each line in the original format "{Line}  #speaker: {Speaker} #portrait: {Expression} #layout: {position} ", 

    """ ''' + dialogue + '''

    """
    
    '''


def add_tags(past_outputs):
    prompt = assemble_prompt_one(past_outputs)
    return add_tags_gpt(prompt)


def add_to_past(string):
    global past_outputs_str
    past_outputs_str += string + "\n"
    return past_outputs_str


def clear_past_output():
    global past_outputs_str
    past_outputs_str = ""
    return past_outputs_str


def set_current_output(string):
    current_output = string


def save_settings(system_message, character_profiles, background_settings):
    with open('default_strings.py', 'w') as file:
        file.write('system_message = """\n' + system_message + '\n"""\n')
        file.write('character_profiles = """\n' +
                   character_profiles + '\n"""\n')
        file.write('background_settings = """\n' +
                   background_settings + '\n"""\n')


def save_to_file(filename, content):
    content = content.replace("\"", "")
    with open(filename, "a") as file:
        file.write("\n"+content)


with gr.Blocks() as demo:

    with gr.Tab("Dialogue generator"):
        with gr.Row():
            with gr.Column():
                prompt = gr.TextArea(label="Summary of scene",
                                     placeholder="Input your summary of the scene here, add as much details as possible")
                output = gr.TextArea(label="Dialogue Output")
                generate_btn = gr.Button("Generate")
                add_to_past_btn = gr.Button("Add to Past Outputs")
            with gr.Column():
                past_outputs = gr.TextArea(
                    label="Past Outputs (add the dialogues you are satisfied with here for future context reference)", value=past_outputs_str)
                clear_output_button = gr.Button("Clear Past Outputs")
                add_tags_button = gr.Button("Reformat and Add Tags")
                preview_result = gr.TextArea(
                    label="Preview result", placeholder="Preview the result before exporting")

                file_name = gr.Textbox(
                    label="File Name(To save dialogue to .txt, .ink)")
                save_to_file_button = gr.Button("Save Dialogue To file")

    with gr.Tab("System settings"):
        system_message_box = gr.Textbox(
            label="System message", value=system_message)
        character_profiles_box = gr. TextArea(
            label="Character Profiles", value=character_profiles)
        background_settings_box = gr.TextArea(
            label="Background_settings", value=background_settings)
        save_settings_button = gr.Button("Save Settings")

    generate_btn.click(fn=generate_dialogue, inputs=[
        prompt, system_message_box, character_profiles_box, background_settings_box], outputs=output)
    add_to_past_btn.click(fn=add_to_past, inputs=output, outputs=past_outputs)
    clear_output_button.click(fn=clear_past_output, outputs=past_outputs)
    add_tags_button.click(fn=add_tags, inputs=past_outputs,
                          outputs=preview_result)
    save_settings_button.click(fn=save_settings, inputs=[
                               system_message_box, character_profiles_box, background_settings_box])
    save_to_file_button.click(fn=save_to_file, inputs=[
                              file_name, preview_result])
demo.launch()
